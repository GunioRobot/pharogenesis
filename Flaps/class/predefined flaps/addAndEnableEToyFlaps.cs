addAndEnableEToyFlaps
	"Initialize the standard default out-of-box set of global flaps.  This method creates them and places them in my class variable #SharedFlapTabs, but does not itself get them displayed."

	| aSuppliesFlap |
	SharedFlapTabs
		ifNotNil: [^ self].
	SharedFlapTabs _ OrderedCollection new.

	aSuppliesFlap _ self newSuppliesFlapFromQuads: self quadsDefiningPlugInSuppliesFlap positioning: #right.
	aSuppliesFlap referent setNameTo: 'Supplies Flap' translated.  "Per request from Kim Rose, 7/19/02"
	SharedFlapTabs add: aSuppliesFlap.  "The #center designation doesn't quite work at the moment"
	SharedFlapTabs add: self newNavigatorFlap.

	self enableGlobalFlapWithID: 'Supplies' translated.
	self enableGlobalFlapWithID: 'Navigator' translated.

	SharedFlapsAllowed _ true.
	Project current flapsSuppressed: false.
	^ SharedFlapTabs

"Flaps addAndEnableEToyFlaps"