resetCommandHistory    "CommandHistory allInstancesDo: [:ch | ch resetCommandHistory]"
	"Clear out the command history so that no commands are held"

	lastCommand _ nil.
	history _ OrderedCollection new.