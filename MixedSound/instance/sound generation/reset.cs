reset

	super reset.
	sounds do: [ :snd | snd reset ].
	soundDone _ (Array new: sounds size) atAllPut: false.
