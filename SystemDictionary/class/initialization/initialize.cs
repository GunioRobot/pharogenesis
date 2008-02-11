initialize
	"SystemDictionary initialize"

	| oldList |
	oldList _ StartUpList.
	StartUpList _ OrderedCollection new.
	"These get processed from the top down..."
	#(
		Delay
		DisplayScreen
		Cursor
		InputSensor
		ProcessorScheduler  "Starts low space watcher and bkground."
		LanguageEnvironment
		FileDirectory  "Enables file stack dump and opens sources."
		NaturalLanguageTranslator
		ShortIntegerArray
		ShortRunArray
		CrLfFileStream
	) do:[:clsName|
		Smalltalk at: clsName ifPresent:[:cls| Smalltalk addToStartUpList: cls].
	].
	oldList ifNotNil: [oldList do: [:className | Smalltalk at: className
						ifPresent: [:theClass | Smalltalk addToStartUpList: theClass]]].
	#(
		ImageSegment
		PasteUpMorph
		ControlManager
	) do:[:clsName|
		Smalltalk at: clsName ifPresent:[:cls| Smalltalk addToStartUpList: cls].
	].
		

	oldList _ ShutDownList.
	ShutDownList _ OrderedCollection new.
	"These get processed from the bottom up..."
	#(
		Delay
		DisplayScreen
		InputSensor
		Form
		ControlManager
		PasteUpMorph
		StrikeFont
		Color
		FileDirectory
		SoundPlayer
		HttpUrl
		Password
		PWS
		MailDB
		ImageSegment
	) do:[:clsName|
		Smalltalk at: clsName ifPresent:[:cls| Smalltalk addToShutDownList: cls].
	].

	oldList ifNotNil: [oldList reverseDo: [:className | Smalltalk at: className
						ifPresent: [:theClass | Smalltalk addToShutDownList: theClass]]].
