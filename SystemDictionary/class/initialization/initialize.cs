initialize
	"SystemDictionary initialize"

	| oldList |
	oldList _ StartUpList.
	StartUpList _ OrderedCollection new.
	"These get processed from the top down..."
	Smalltalk addToStartUpList: DisplayScreen.
	Smalltalk addToStartUpList: Cursor.
	Smalltalk addToStartUpList: InputSensor.
	Smalltalk addToStartUpList: ProcessorScheduler.  "Starts low space watcher and bkground."
	Smalltalk addToStartUpList: Delay.
	Smalltalk addToStartUpList: FileDirectory.  "Enables file stack dump and opens sources."
	Smalltalk addToStartUpList: ShortIntegerArray.
	Smalltalk addToStartUpList: ShortRunArray.
	Smalltalk addToStartUpList: CrLfFileStream.
	oldList ifNotNil: [oldList do: [:className | Smalltalk at: className
						ifPresent: [:theClass | Smalltalk addToStartUpList: theClass]]].
	Smalltalk addToStartUpList: ImageSegment.
	Smalltalk addToStartUpList: PasteUpMorph.
	Smalltalk addToStartUpList: ControlManager.

	oldList _ ShutDownList.
	ShutDownList _ OrderedCollection new.
	"These get processed from the bottom up..."
	Smalltalk addToShutDownList: DisplayScreen.
	Smalltalk addToShutDownList: Form.
	Smalltalk addToShutDownList: ControlManager.
	Smalltalk addToShutDownList: StrikeFont.
	Smalltalk addToShutDownList: Color.
	Smalltalk addToShutDownList: FileDirectory.
	Smalltalk addToShutDownList: Delay.
	Smalltalk addToShutDownList: SoundPlayer.
	Smalltalk addToShutDownList: HttpUrl.
	Smalltalk addToShutDownList: Password.
	Smalltalk addToShutDownList: PWS.
	Smalltalk addToShutDownList: MailDB.
	Smalltalk addToShutDownList: ImageSegment.

	oldList ifNotNil: [oldList reverseDo: [:className | Smalltalk at: className
						ifPresent: [:theClass | Smalltalk addToShutDownList: theClass]]].
