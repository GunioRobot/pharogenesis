internalStackValue: offset

	^ self longAt: localSP - (offset * 4)