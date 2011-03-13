forget: aProject

	AllProjects _ self allProjects reject: [ :x | x == aProject].
