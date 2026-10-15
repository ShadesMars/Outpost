using Content.Shared._RMC14.Marines.Roles.Ranks;
using Content.Shared.Roles;
using Robust.Shared.Prototypes;

// ReSharper disable once CheckNamespace
namespace Content.Shared.Preferences;

public sealed partial class HumanoidCharacterProfile
{
    /// <summary>
    /// When spawning in, decides what type of rank to give based on job. (Also dependent on playtime)
    /// </summary>
    [DataField]
    private Dictionary<ProtoId<JobPrototype>, ProtoId<RankPrototype>?> _rankPreferences = new();

    /// <summary>
    /// <see cref="_rankPreferences"/>
    /// </summary>
    public IReadOnlyDictionary<ProtoId<JobPrototype>, ProtoId<RankPrototype>?> RankPreferences => _rankPreferences;

    public HumanoidCharacterProfile WithRankPreference(ProtoId<JobPrototype> jobId, ProtoId<RankPrototype>? rankId)
    {
        var dictionary = new Dictionary<ProtoId<JobPrototype>, ProtoId<RankPrototype>?>(_rankPreferences);

        if (rankId == null)
            dictionary.Remove(jobId);
        else
            dictionary[jobId] = rankId;

        return new(this) { _rankPreferences = dictionary };
    }
}
