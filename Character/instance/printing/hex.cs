hex
	^ String with: ('0123456789ABCDEF' at: value//16+1)
			with:  ('0123456789ABCDEF' at: value\\16+1)