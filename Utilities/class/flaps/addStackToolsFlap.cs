addStackToolsFlap
	"Add a flap with stack tools in it"

	| aFlap aFlapTab aTextMorph aSketch  aMorph |
	"Utilities reinstateDefaultFlaps. Utilities addStackToolsFlap"
	(ScriptingSystem formAtKey: #CedarPic) ifNil:
		[^ self notYetImplemented].

	aFlap _ self newPartsFlapPage beSticky.
	aFlap setProperty: #maximumThumbnailWidth toValue: 80.
	aFlap setProperty: #flap toValue: true.
	aFlap color: (Color green muchLighter lighter alpha: 0.3).

	aFlapTab _ FlapTab new referent: aFlap.
	aFlapTab assumeString: 'Stack Tools' font: Preferences standardFlapFont orientation: #horizontal color: Color brown lighter lighter.
	aFlapTab edgeToAdhereTo: #bottom; inboard: false.
	aFlapTab setToPopOutOnDragOver: false.
	aFlapTab setToPopOutOnMouseOver: false.

	aFlap addMorphBack: StackMorph authoringPrototype.

	aTextMorph _ TextMorph authoringPrototype.
	aTextMorph contents: 'background
label' asText.  
	aTextMorph beAllFont: (StrikeFont familyName: #NewYork size: 18).
	aTextMorph color: Color brown.
	aTextMorph setProperty: #shared toValue: true.
	aFlap addMorphBack: aTextMorph.

	"Ted's fields, maybe good point of departure...
	aTextMorph _ TextFieldMorph authoringPrototype.
	aTextMorph setProperty: #shared toValue: true.
	aFlap addMorphBack: aTextMorph."

	aFlap addMorphBack: ScriptableButton authoringPrototype markAsPartsDonor beSticky.

	"NB: Here is where we will put the prototype(s) for background/foreground fields; for the moment, vanilla TextMorphs are used, with the scrolling PTMWM temporarily commented out pending some more work.  A successor to Ted's TextFieldMorph, or some new kind of carefully-thought-through morph that will generally serve the community as the archetypal 'Field', is ultimately needed"

	#(TextMorph "PluggableTextMorphWithModel" TextFieldMorph ) do:
		[:sym |
			aMorph _ (Smalltalk at: sym) authoringPrototype.
			aMorph contents: 'background field' asText allBold.
			aMorph setProperty: #shared toValue: true.
			aMorph setNameTo: (sym == #TextMorph ifTrue: ['field1'] ifFalse: ['scrollingField1']).
			aMorph setProperty: #holdsSeparateDataForEachInstance toValue: true.
			aFlap addMorphBack: aMorph].

	"aFlap addMorphBack: ScriptableListMorph authoringPrototype beSticky -- SOON!"
	
	#(CedarPic) do:
		[:sym | 
			aSketch _ SketchMorph newSticky form: ((ScriptingSystem formAtKey: sym) ifNil: [ScriptingSystem formAtKey: #squeakyMouse]).
			aSketch setProperty: #shared toValue: true.
			aSketch setProperty: #holdsSeparateDataForEachInstance toValue: true.
			aFlap addMorphBack: aSketch].

	"aCardReference _ CardReference authoringProtoype beSticky.
	aCardReference card: Card new.  "

	aFlap addMorphBack: StackMorph previousCardButton markAsPartsDonor.
	aFlap addMorphBack: StackMorph nextCardButton markAsPartsDonor.

	#( PaintInvokingMorph "ImageMorph  RectangleMorph EllipseMorph StarMorph  CurveMorph PolygonMorph SimpleSliderMorph") do:
		[:sym | aFlap addMorphBack: (Smalltalk at: sym) authoringPrototype].

	aFlap addMorphBack: TrashCanMorph new markAsPartsDonor.
	aFlap addMorphBack: ScriptingSystem scriptControlButtons markAsPartsDonor.

	aFlap replaceTallSubmorphsByThumbnails.

	aFlapTab position: ((2 * (self currentWorld width // 3)) @ (self currentWorld height - aFlapTab height)).

	aFlap setProperty: #flap toValue: true.
	aFlap color: (Color red muchLighter "alpha: 0.2").
	aFlap extent: self currentWorld width @ 100.
	
	self currentWorld addMorphFront: aFlapTab.  
	"a local flap, but we could as easily make it global by:
		self addGlobalFlap: aFlapTab.  self currentWorld addGlobalFlaps"