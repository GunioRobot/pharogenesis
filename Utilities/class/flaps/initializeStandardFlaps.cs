initializeStandardFlaps
	"Utilities initializeStandardFlaps"
	FlapTabs _ OrderedCollection new.
	FlapTabs add: (self standardLeftFlap setToPopOutOnDragOver: false).
	FlapTabs add: self standardBottomFlap.
	FlapTabs add: self standardRightFlap.
	FlapTabs add: (self menuFlap setToPopOutOnDragOver: false).
	FlapTabs do:
		[:aFlapTab | 
			aFlapTab setToPopOutOnMouseOver: false].

	^ FlapTabs