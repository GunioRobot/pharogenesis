newFlapTitled: aString onEdge: anEdge inPasteUp: aPasteUpMorph
	| aFlap aFlapTab  orientation |

	aFlap _ PasteUpMorph newSticky.
	aFlapTab _ FlapTab new referent: aFlap.
	orientation _ (#(left right) includes: anEdge)
		ifTrue:	[#vertical]
		ifFalse:	[#horizontal].
	aFlapTab 
		assumeString: aString 
		font: Preferences standardFlapFont 
		orientation: orientation 
		color: Color veryLightGray.
	aFlapTab edgeToAdhereTo: anEdge; inboard: false.

	anEdge == #left ifTrue:
		[aFlapTab position: (aPasteUpMorph left @ aPasteUpMorph top).
		aFlap extent: (200 @ aPasteUpMorph height)].
	anEdge == #right ifTrue:
		[aFlapTab position: ((aPasteUpMorph right - aFlapTab width) @ aPasteUpMorph top).
		aFlap extent: (200 @ aPasteUpMorph height)].
	anEdge == #top ifTrue:
		[aFlapTab position: ((aPasteUpMorph left + 50) @ aPasteUpMorph top).
		aFlap extent: (aPasteUpMorph width @ 200)].
	anEdge == #bottom ifTrue:
		[aFlapTab position: ((aPasteUpMorph left + 50) @ (aPasteUpMorph bottom - aFlapTab height)).
		aFlap extent: (aPasteUpMorph width @ 200)].

	aFlap beFlap: true.
	aFlap color: (Color veryLightGray muchLighter).

	^ aFlapTab