updateStatusMorph: statusMorph
	"My status button may need to reflect an externally-induced change in status"

	(playerScripted existingScriptInstantiationForSelector: scriptName) ifNotNilDo:
		[:scriptInstantiation |
			scriptInstantiation updateStatusMorph: statusMorph]