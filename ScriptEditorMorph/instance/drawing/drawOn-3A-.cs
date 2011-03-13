drawOn: aCanvas
	| ww |
	"need to unhibernate"

	(ww _ self world) ifNotNil: ["don't hunt agressively for a world"
		(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifTrue: [
			self submorphs size < 2 ifTrue: [
				WorldState addDeferredUIMessage: [self unhibernate] fixTemps]]].
	^ super drawOn: aCanvas