addStandardFlaps
	"Initialize the standard default out-of-box set of global flaps. 
	This method creates them and places them in my class 
	variable #SharedFlapTabs, but does not itself get them 
	displayed. "
	SharedFlapTabs ifNil: [SharedFlapTabs := OrderedCollection new].
	SharedFlapTabs add: self newPharoFlap.
	"SharedFlapTabs add: self newPaintingFlap. Temporarily commented to make flaps working again until painting morph is fixed"
	self disableGlobalFlapWithID: 'Stack Tools' translated.
	self disableGlobalFlapWithID: 'Painting' translated.
	^ SharedFlapTabs