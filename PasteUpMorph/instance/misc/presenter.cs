presenter
	"Normally only the world will have a presenter, but the architecture supports individual localized presenters as well"

	^ presenter ifNil: [super presenter] ifNotNil: [presenter]