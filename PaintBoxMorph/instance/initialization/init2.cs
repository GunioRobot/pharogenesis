init2
	"Select and execute these for various initializations"

	|  ll |
	self loadImages: 'Back'.
	self createButtons.
	image fill: (colorPatch bounds translateBy: self topLeft negated)
		fillColor: Color white.	"colorPatch for transparent"
	"Create the other three pickUp buttons and the stamp buttons"
	self loadOnImage: 'Back-on'	.
	self on: #mouseDown send: #yourself to: self.
	self loadPressedImage: 'Back-in'	.

stampHolder _ ScrollingToolHolder new.
'AA _ submorphs select: [:each | 
	each class == ThreePhaseButtonMorph ifTrue: [
			(each arguments at: 2) == #pickup:]
	ifFalse: [false]].
AA _ AA reversed.   stampHolder pickupButtons: AA.
stampHolder stampButtons: AA.	"after collecting them"
AA do: [:each | each actionSelector: #pickup:action:cursor:].	"both stamps and pickup buttons"		'.
stampHolder "stampButtons" pickupButtons do: [:each | 
	each instVarNamed: 'image' "on" put: (each instVarNamed: 'pressedImage')].
stampHolder stampButtons do: [:each | 
	ll _ LayoutMorph newRow.
	self addMorphFront: ll.  ll inset: 0; borderWidth: 3.
	ll hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	ll bounds: (each bounds expandBy: 3).
	ll addMorphFront: each.
	ll color: Color transparent; borderColor: Color transparent.
	].


thumbnail _ submorphs last.	"can't use findA: RectangleMorph"
(self findButton: #toss:) actionSelector: #toss:with: .
(self findButton: #keep:) actionSelector: #keep:with: .
(self findButton: #undo:) actionSelector: #undo:with: .
(self findButton: #eyedropper:) actionSelector: #eyedropper:action:cursor: .
(self findButton: #eyedropper:) actWhen: #buttonUp.
(self findButton: #prevStamp:) actionSelector: #scrollStamps:action:.
(self findButton: #nextStamp:) actionSelector: #scrollStamps:action:.
colorMemory _ self findA: ColorMemoryMorph.
colorMemory on: #mouseUp send: #takeColorEvt:from: to: self.
self stampCursorBeCursorFor: #star:.
currentCursor offset: 9@3.
