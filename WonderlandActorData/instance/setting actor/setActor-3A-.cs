setActor: anActor
	"Set the actor whose data this morph should show and update the displayed data."

	| position rotation |

	(anActor isNil)
		ifTrue: [
				nameMorph contents: 'Name: (No actor selected)'.
				parentMorph contents: 'Parent: '.	
				positionMorph contents: ((Character tab) asString) , 'Right:    Up:    Forward: '.
				rotationMorph contents: ((Character tab) asString) , 'Left-Right axis: ' ,
					((Character cr) asString) , ((Character tab) asString) , 'Up-Down axis: ',
					((Character cr) asString) , ((Character tab) asString) , 'Forward-Back axis: '.
				]

		ifFalse: [
				nameMorph contents: ('Name: ' , (anActor getName)).

				(anActor isKindOf: WonderlandActor)
					ifTrue: [
							parentMorph contents: ('Parent: ' , (anActor getParent getName)).

							position _ anActor getPosition.
							position at: 1 put: ((((position at: 1) * 1000) rounded / 1000.0) asString).
							position at: 2 put: ((((position at: 2) * 1000) rounded / 1000.0) asString).
							position at: 3 put: ((((position at: 3) * 1000) rounded / 1000.0) asString).
							positionMorph contents: ((Character tab) asString) , ('Right: ',
								(position at: 1) , '  Up: ', (position at: 2) , '  Forward: ' ,
								(position at: 3)).

							rotation _ anActor getAngles.
							rotation at: 1 put: ((((rotation at: 1) * 1000) rounded / 1000.0) asString).
							rotation at: 2 put: ((((rotation at: 2) * 1000) rounded / 1000.0) asString).
							rotation at: 3 put: ((((rotation at: 3) * 1000) rounded / 1000.0) asString).
							rotationMorph contents: ((Character tab) asString) , 'Left-Right axis: ' ,
								(rotation at: 1) , ((Character cr) asString) ,
								((Character tab) asString) , 'Up-Down axis: ' , (rotation at: 2) , 
								((Character cr) asString) , ((Character tab) asString) ,
								'Forward-Back axis: ' , (rotation at: 3).

							]
					ifFalse: [
							parentMorph contents: 'Parent: None'.	
							positionMorph contents: ((Character tab) asString) ,
									'Right:    Up:    Forward: '.
							rotationMorph contents: ((Character tab) asString) , 'Left-Right axis: ' ,
								((Character cr) asString) , ((Character tab) asString) ,
								'Up-Down axis: ', ((Character cr) asString) ,
								((Character tab) asString) , 'Forward-Back axis: '.
							]

				].



