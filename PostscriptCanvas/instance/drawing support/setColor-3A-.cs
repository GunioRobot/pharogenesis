setColor: color 
     currentColor ~= color ifTrue:[
          target write:color asColor.
		currentColor _ color.
	].
