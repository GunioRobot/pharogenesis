doInOrder: commands
	"Create a nameless inOrder script with the specified commands"

	^ AliceScript new: inOrder withCommands: commands in: self.
