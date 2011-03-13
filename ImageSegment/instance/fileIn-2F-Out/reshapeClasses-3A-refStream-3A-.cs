reshapeClasses: mapFakeClassesToReal refStream: smartRefStream 

	| bads allVarMaps perfect insts partials in out |

	self flag: #bobconv.	

	partials _ OrderedCollection new.
	bads _ OrderedCollection new.
	allVarMaps _ IdentityDictionary new.
	mapFakeClassesToReal keysAndValuesDo: [ :aFakeClass :theRealClass | 
		(theRealClass indexIfCompact > 0) "and there is a fake class"
			ifFalse: [insts _ aFakeClass allInstances]
			ifTrue: ["instances have the wrong class.  Fix them before anyone notices."
				insts _ OrderedCollection new.
				self allObjectsDo: [:obj | obj class == theRealClass ifTrue: [insts add: obj]].
			].
		insts do: [ :misShapen | 
			perfect _ smartRefStream convert1: misShapen to: theRealClass allVarMaps: allVarMaps.
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

	in _ OrderedCollection new.
	out _ OrderedCollection new.
	partials do: [ :each |
		perfect _ smartRefStream convert2: each allVarMaps: allVarMaps.
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
