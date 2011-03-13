tearDown
	[ gofer unload ]
		on: Error
		do: [ :err | "assume it is not there" ]