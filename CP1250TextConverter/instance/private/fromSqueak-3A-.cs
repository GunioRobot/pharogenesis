fromSqueak: char

	^ Character value: (FromTable at: char charCode ifAbsent: [char asciiValue])