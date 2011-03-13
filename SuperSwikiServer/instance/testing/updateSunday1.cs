updateSunday1

	self sendToSwikiProjectServer: {
		'action: updatepage'.
		'projectname: sunday1'.
		'projectdescription: blah blah blah.'.
		'projectcategory: Educational.'.
		'projectsubcategory: Geometry.'.
		'projectages: 10 and up.'.
		'projectkeywords: triangles Pythagoras moon.'.
		'projectlinks: More Triangles.Bio of Pythagoras.Geometry Index'.
	}