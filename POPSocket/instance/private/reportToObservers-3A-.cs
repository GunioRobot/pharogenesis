reportToObservers: aString
	"send aString to all observers"
	progressObservers do: [ :observer |
		observer show: aString.
		aString last = Character cr ifFalse: [ observer show: String cr ]].