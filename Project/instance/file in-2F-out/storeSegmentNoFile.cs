storeSegmentNoFile
	"For testing. Make an ImageSegment. Keep the outPointers in memory.
	Also useful if you want to enumerate the objects in the segment
	afterwards (allObjectsDo:)"
	| is str |
	World == world
		ifTrue: [^ self].
	"inform: 'Can''t send the current world out'."
	world isInMemory
		ifFalse: [^ self].
	"already done"
	"Only Morphic projects for now"
	world
		ifNil: [^ self].
	world presenter
		ifNil: [^ self].
	"Do this on project enter"
	World flapTabs
		do: [:ft | ft referent adaptToWorld: World].
	"Hack to keep the Menu flap from pointing at my project"
	"Preferences setPreference: #useGlobalFlaps toValue: false."
	"Utilities globalFlapTabsIfAny do:
	[:aFlapTab | Utilities removeFlapTab: aFlapTab keepInList: false].
	Utilities clobberFlapTabList.	"
	"project world deleteAllFlapArtifacts."
	"self currentWorld deleteAllFlapArtifacts.	"
	World checkCurrentHandForObjectToPaste2.
	is := ImageSegment new
				copyFromRootsLocalFileFor: (Array with: world presenter with: world)
				sizeHint: 0.
	"world, and all Players"
	is segment size < 800
		ifTrue: ["debugging"
			Transcript show: self name , ' did not get enough objects';
				 cr.
			^ Beeper beep].
	false
		ifTrue: [str := String
						streamContents: [:strm | 
							strm nextPutAll: 'Only a tiny part of the project got into the segment'.
							strm nextPutAll: '\These are pointed to from the outside:' withCRs.
							is outPointers
								do: [:out | 
									out class == Presenter 
										ifTrue: [strm cr.
											out printOn: strm.
											self systemNavigation
												browseAllObjectReferencesTo: out
												except: (Array with: is outPointers)
												ifNone: [:obj | obj]].
									(is arrayOfRoots includes: out class)
										ifTrue: [strm cr.
											out printOn: strm.
											self systemNavigation
												browseAllObjectReferencesTo: out
												except: (Array with: is outPointers)
												ifNone: [:obj | obj]]]].
			self inform: str.
			^ is inspect].
	is extract 