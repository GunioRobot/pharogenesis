assignStatus: newStatus toAllFor: scriptName
	"Change the status of my script of the given name to be as specified in me and all of my siblings."

	| aWorld |
	(self existingScriptInstantiationForSelector: scriptName) ifNotNilDo:
		[:scriptInstantiation |
				scriptInstantiation status: newStatus.
				scriptInstantiation assignStatusToAllSiblings.
				^ (aWorld _ self costume world) ifNotNil:
					[aWorld updateStatusForAllScriptEditors]]