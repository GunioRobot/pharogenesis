replaceScriptingAreaInToolsFlap
	"Utilities replaceScriptingAreaInToolsFlap"
	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isKindOf: ScriptingDomain]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  ScriptingSystem newScriptingSpace