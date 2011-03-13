filteringScheme
	"The filteringScheme dictates how the viewer will obtain the subparts to show.  In the first implementation, we used the following choices:
		minimal		specially-designated methods in root class + everything defined in uniclass
		standard	a canonical point of departure
		most		everything up to but not including Object
		custom		everything up to but not including some limit class designated by user
		myOwn		exactly the methods of defined in my own class (like existing Smalltalk browsers)
		all			everything from root class right up to Object"

	"Later we may want individual category viewers to have their own choice here, but for now we have a single control for the entire outer viewer??"

	| determiner |
	(determiner _ self ownerThatIsA: StandardViewer) ifNil: [^ #standard].
	^ determiner filteringScheme