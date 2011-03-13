setSilentPhoneme
	"Prompt the user for the name and mouth position associated with silence."

	self promptForDetailsOfPhoneme: recognizer silentPhoneme.
	phonemeDisplay contents: recognizer silentPhoneme name.
