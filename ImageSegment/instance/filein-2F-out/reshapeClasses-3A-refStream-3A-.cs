reshapeClasses: mapFakeClassesToReal refStream: smartRefStream 

	| bads allVarMaps perfect insts partials in out |

	self flag: #bobconv.	

	partials := OrderedCollection new.
	bads := OrderedCollection new.
	allVarMaps := IdentityDictionary new.
	mapFakeClassesToReal keysAndValuesDo: [ :aFakeClass :theRealClass | 
		(theRealClass indexIfCompact > 0) "and there is a fake class"
			ifFalse: [insts := aFakeClass allInstances]
			ifTrue: ["instances have the wrong class.  Fix them before anyone notices."
				insts := OrderedCollection new.
				self allObjectsDo: [:obj | obj class == theRealClass ifTrue: [insts add: obj]].
			].
		insts do: [ :misShapen | 
			perfect := smartRefStream convert1: misShapen to: theRealClass allVarMaps: allVarMaps.
			bads 
				detect: [ :x | x == misShapen] 
				ifNone: [
					bads add: misShapen.
					partials add: perfect
				].
		].
	].
	bads isEmpty ifFalse: [
		bads asArray elementsForwardIdentityTo: partials asArray
	].

	in := OrderedCollection new.
	out := OrderedCollection new.
	partials do: [ :each |
		perfect := smartRefStream convert2: each allVarMaps: allVarMaps.
		in 
			detect: [ :x | x == each]
			ifNone: [
				in add: each.
				out add: perfect
			]
	].
	in isEmpty ifFalse: [
		in asArray elementsForwardIdentityTo: out asArray
	].
