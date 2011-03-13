disableProgrammerFacilitiesWithoutWarning
	"Warning: do not call this lightly!  It disables all access to menus, debuggers, halos.  There is no guaranteed return from this, which is to say, you cannot necessarily reenable these things once they are disabled -- you can only use whatever the UI of the current project affords, and you cannot even snapshot -- you can only quit."

	self disable: #cmdDotEnabled.	"No user-interrupt-into-debugger"
	self disable: #editableStringMorphs. "turn off shift-click editing"
	ToolSet registeredClasses copy do: [:c | ToolSet unregister: c].
	ToolSet default: nil. "unregister and make sure default is nil to really prevent debug windows"
		"also now takes care of low space watcher interrupts"
	self compileHardCodedPref: #cmdGesturesEnabled enable: false.	"No halos, etc."
	self compileHardCodedPref: #cmdKeysInText enable: false.	"No user commands invokable via cmd-key combos in text editor"
	self enable: #noviceMode.	"No control-menu"
	self disable: #warnIfNoSourcesFile.
	self disable: #warnIfNoChangesFile