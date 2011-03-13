noteSpecialSelector: selectorSymbol
	" special > 0 denotes specially treated messages. "

	"Deconvert initial keywords from SQ2K"
	special _ #(:Test:Yes: :Test:No: :Test:Yes:No: :Test:No:Yes:
				and: or:
				:Until:do: :While:do: whileFalse whileTrue
				:Repeat:to:do: :Repeat:to:by:do:
				) indexOf: selectorSymbol.
	special > 0 ifTrue: [^ self].

	special _ MacroSelectors indexOf: selectorSymbol.
