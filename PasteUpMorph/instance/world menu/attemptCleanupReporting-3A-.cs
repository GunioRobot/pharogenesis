attemptCleanupReporting: whetherToReport
	"Try to fix up some bad things that are known to occur in some etoy projects we've seen. If the whetherToReport parameter is true, an informer is presented after the cleanups"

	| fixes |
	fixes _ 0.
	ActiveWorld ifNotNil:
		[(ActiveWorld submorphs select:
			[:m | (m isKindOf: ScriptEditorMorph) and: [m submorphs isEmpty]]) do:
				[:m | m delete.  fixes _ fixes + 1]].

	TransformationMorph allSubInstancesDo:
		[:m | (m player notNil and: [m renderedMorph ~~ m])
			ifTrue:
				[m renderedMorph visible ifFalse:
					[m renderedMorph visible: true.  fixes _ fixes + 1]]].

	(Player class allSubInstances select: [:cl | cl isUniClass]) do:
		[:aUniclass |
			fixes _ fixes + aUniclass cleanseScripts].

	self presenter flushPlayerListCache; allExtantPlayers.
	whetherToReport ifTrue:
		[self inform: ('{1} [or more] repair(s) made' translated format: {fixes printString})]

"
ActiveWorld attemptCleanupReporting: true.
ActiveWorld attemptCleanupReporting: false.
"