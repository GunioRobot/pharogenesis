replaceChangeSortersInToolsFlap
	"Get prototypes of the latest versions of the the Change Sorters into the Tools flap"

	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: ChangeSorter]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  (ChangeSorter new morphicWindow applyModelExtent).

	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: DualChangeSorter]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  (DualChangeSorter new morphicWindow applyModelExtent)
