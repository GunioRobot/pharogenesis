select: n values: values selection: selection size: size 
	^ self
		select: n
		values: values
		selections: (Array with: selection)
		size: size
		multiple: false