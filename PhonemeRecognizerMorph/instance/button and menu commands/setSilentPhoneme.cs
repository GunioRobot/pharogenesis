setSilentPhoneme
	"Prompt the user for the name and mouth position associated with silence."

	self promptForDetailsOfPhoneme: silentPhoneme.
	phonemeDisplay contents: currentPhoneme name.
