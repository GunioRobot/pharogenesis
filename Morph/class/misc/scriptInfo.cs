scriptInfo
	"Answer a list of arrays which characterize etoy script commands understood by this kind of morph -- in addition to those already defined by superclasses.  Implementors of this method are statically polled to contribute this information when the scripting system reinitializes its scripting info, which typically only happens after a structural change."

	^ #((command beep: sound)
		(command bounce: sound)
		(command forward: number)
		(command followPath)
		(command goToRightOf: player)
		(command doMenuItem: menu)
		(command hide)
		(command makeNewDrawingIn: player)
		(command moveToward: player)
		(command pauseScript: string)
		(command show)
		(command startScript: string)
		(command stopScript: string)
		(command turn: number)
		(command wearCostumeOf: player)
		(command wrap))
