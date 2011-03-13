installOn: aDisplayContext foregroundColor: fgColor backgroundColor: bgColor

	foregroundColor _ fgColor.
	fontArray do: [:s | s ifNotNil: [s installOn: aDisplayContext foregroundColor: fgColor backgroundColor: bgColor]].
