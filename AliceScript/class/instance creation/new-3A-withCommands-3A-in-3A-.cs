new: type withCommands: commands in: anAliceWorld
	"Create a new nameless (lambda) script containing the specified commands"

	| newScript |

	newScript _ AliceScript new initialize: anAliceWorld.
	newScript setScriptType: type.
	newScript setCommands: commands.

	^ newScript.

