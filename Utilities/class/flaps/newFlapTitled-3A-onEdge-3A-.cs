newFlapTitled: aString onEdge: anEdge
	| aFlap aFlapTab  orientation |

	aFlap _ PasteUpMorph newSticky.
	aFlapTab _ FlapTab new referent: aFlap.
	orientation _ (#(left right) includes: anEdge)
		ifTrue:	[#vertical]
		ifFalse:	[#horizontal].
	aFlapTab assumeString: aString font: Preferences standardFlapFont orientation: orientation color: Color veryLightGray.
	aFlapTab edgeToAdhereTo: anEdge; inboard: false.

	anEdge == #left ifTrue:
		[aFlapTab position: (0 @ 0).
		aFlap extent: (200 @ self currentWorld height)].
	anEdge == #right ifTrue:
		[aFlapTab position: ((self currentWorld width - aFlapTab width) @ 0).
		aFlap extent: (200 @ self currentWorld height)].
	anEdge == #top ifTrue:
		[aFlapTab position: (50 @ 0).
		aFlap extent: (self currentWorld width @ 200)].
	anEdge == #bottom ifTrue:
		[aFlapTab position: (50 @ (self currentWorld height - aFlap height)).
		aFlap extent: (self currentWorld width @ 200)].

	aFlap setProperty: #flap toValue: true.
	aFlap color: (Color veryLightGray muchLighter).

	^ aFlapTab