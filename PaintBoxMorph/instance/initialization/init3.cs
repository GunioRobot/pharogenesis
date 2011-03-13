init3
	"Just a record of how we loaded in the latest paintbox button images"
| bb rect lay pic16Bit aa blt on thin |
self loadoffImage: 'etoy_default.gif'.
self allMorphsDo: [:button |
	(button isKindOf: ThreePhaseButtonMorph) 
		ifTrue: [button offImage: nil]
		ifFalse: [button position: button position + (100@0)]].
(bb _ self submorphNamed: #keep:) position: bb position + (100@0).
(bb _ self submorphNamed: #toss:) position: bb position + (100@0).
(bb _ self submorphNamed: #undo:) position: bb position + (100@0).
"Transparent is (Color r: 1.0 g: 0 b: 1.0)"

self moveButtons.
self loadOnImage: 'etoy_in.gif'.
AllOnImage _ nil.	'save space'.	
self loadPressedImage: 'etoy_in.gif'.
AllPressedImage _ nil.	'save space'.
self loadCursors.

"position the stamp buttons"
stampHolder stampButtons owner last delete.
stampHolder pickupButtons last delete.
stampHolder stampButtons: (stampHolder stampButtons copyFrom: 1 to: 3).
stampHolder pickupButtons: (stampHolder pickupButtons copyFrom: 1 to: 3).
"| rect |"
stampHolder pickupButtons do: [:button |
		"PopUpMenu notify: 'Rectangle for ',sel."
		rect _ Rectangle fromUser.
		button bounds: rect.	"image is nil"
		].
"| rect lay |"
stampHolder clear.
stampHolder stampButtons do: [:button |
		button offImage: nil; pressedImage: nil.
		lay _ button owner.
		"PopUpMenu notify: 'Rectangle for ',sel."
		rect _ Rectangle fromUser.
		button image: (Form fromDisplay: (rect insetBy: 2)).
		lay borderWidth: 2.
		lay bounds: rect.	"image is nil"
		].
"| pic16Bit blt aa on |"
	pic16Bit "really 8" _ GIFReadWriter formFromFileNamed: 'etoy_in.gif'.
	aa _ Form extent: OriginalBounds extent depth: 8.
	blt _ BitBlt current toForm: aa.
	blt sourceForm: pic16Bit; combinationRule: Form over;
		sourceRect: OriginalBounds; destOrigin: 0@0; copyBits.
	"Collect all the images for the buttons in the on state"
	stampHolder pickupButtons do: [:button |
			on _ ColorForm extent: button extent depth: 8.
					 on colors: pic16Bit colors.
			on copy: (0@0 extent: button extent)
				from: (button topLeft - self topLeft) in: aa rule: Form over.
			button image: on; pressedImage: on; offImage: nil.
			].
	self invalidRect: bounds.

((self submorphNamed: #erase:) arguments at: 3) offset: (12@35).
((self submorphNamed: #eyedropper:) arguments at: 3) offset: (0@0).
((self submorphNamed: #fill:) arguments at: 3) offset: (10@44).
((self submorphNamed: #paint:) arguments at: 3) offset: (3@3). "unused"
((self submorphNamed: #rect:) arguments at: 3) offset: (6@17).
((self submorphNamed: #ellipse:) arguments at: 3) offset: (5@4).
((self submorphNamed: #polygon:) arguments at: 3) offset: (5@4).
((self submorphNamed: #line:) arguments at: 3) offset: (5@17).
((self submorphNamed: #star:) arguments at: 3) offset: (2@5).
thumbnail delete.
thumbnail _ nil.
(submorphs select: [:e | e class == RectangleMorph]) first bounds: 
	Rectangle fromUser.
(submorphs select: [:e | e class == RectangleMorph]) first borderWidth: 1; borderColor: Color black.
"| thin |"
	submorphs do: [:ss | ss class == ImageMorph ifTrue: [thin _ ss "first"]].
colorMemoryThin _ thin.
