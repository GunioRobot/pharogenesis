eToyVersion: aVersion date: dateStringOrDate
	"For calling from a fileIn"

	EToyVersion _ aVersion.
	EToyVersionDate _ dateStringOrDate asString.
	Smalltalk setVersion: EToyVersion , ' of ' , EToyVersionDate