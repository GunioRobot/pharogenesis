closeExampleDialogs
	"Close the example dialogs."

	DialogWindow allSubInstances do: [:d | d cancel]