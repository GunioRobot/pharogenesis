dispatchEvent: event to: aMorph
	| evt delta |
	evt _ event getMorphicEvent.
	delta _ (myTexture mapPrimitiveVertex: event getVertex) - evt position.
	evt _ evt translatedBy: delta.
	evt resetHandlerFields.
	"Make sure my texture thinks it's in the world otherwise we might run into problems"
	aMorph isInWorld ifFalse:[aMorph privateOwner: event getCameraMorph].
	aMorph processEvent: evt.