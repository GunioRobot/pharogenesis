send: startUpOrShutDown toClassesNamedIn: startUpOrShutDownList with: argument
	"Send the message #startUp: or #shutDown: to each class named in the list.
	The argument indicates if the system is about to quit (for #startUp:) or if
	the image is resuming (for #startUp:).
	If any name cannot be found, then remove it from the list."

	| removals class |
	removals _ OrderedCollection new.
	startUpOrShutDownList do:
		[:name |
		class _ self at: name ifAbsent: [nil].
		class == nil
			ifTrue: [removals add: name]
			ifFalse: [class perform: startUpOrShutDown with: argument]].

	"Remove any obsolete entries, but after the iteration"
	startUpOrShutDownList removeAll: removals