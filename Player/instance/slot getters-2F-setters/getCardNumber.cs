getCardNumber
	"Answer the current card number"

	| aStack |
	^ (aStack _ self stackEmbodied) cardNumberOf: aStack currentCard