upDownArrows
	"Return an array of two up/down arrow buttons.
	It replaces the selector or arg with a new one.
	I am a number or boolean or a selector (beep:, +,-,*,//,\\, or setX: incX: decX: for any X."
	| patch any noMenu |
	any _ (self nodeClassIs: LiteralNode) and: [parseNode key isNumber].
	any _ any or: [(self nodeClassIs: VariableNode) and:
						[(#('true' 'false') includes: self decompile asString)]].
	noMenu _ any.

	any _ any or: [self nodeClassIs: SelectorNode].	"arrows and menu of selectors"
	any _ any or: [self nodeClassIs: KeyWordNode].
	any ifFalse: [^ nil].

	patch _ {(ImageMorph new image: TileMorph upPicture)
				on: #mouseDown send: #upDown:event:arrow: to: self withValue: 1;
				on: #mouseStillDown send: #upDownMore:event:arrow: 
					to: self withValue: 1;
				on: #mouseUp send: #upDownDone to: self.
			(ImageMorph new image: TileMorph downPicture)
				on: #mouseDown send: #upDown:event:arrow: to: self withValue: -1;
				on: #mouseStillDown send: #upDownMore:event:arrow: 
					to: self withValue: -1;
				on: #mouseUp send: #upDownDone to: self}.
	noMenu ifFalse: [patch _ patch, {(RectangleMorph new)
						extent: 6@10; borderWidth: 1;
						borderColor: Color gray;
						on: #mouseUp send: #selectorMenu to: self}.
					patch last color: ((self nodeClassIs: SelectorNode) 
						ifTrue: [Color lightGreen] ifFalse: [Color red darker])].
	^ patch