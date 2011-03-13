updateProject3

	self sendToSwikiProjectServer: {
		'action: updatepage'.
		'projectname: My Project3'.
		'projectdescription: This project explores uses of triangles. Calculating the distance to the moon is one of the exercises.'.
		'projectcategory: Educational.'.
		'projectsubcategory: Geometry.'.
		'projectages: 10 and up.'.
		'projectkeywords: triangles Pythagoras moon.'.
		'projectlinks: More Triangles.Bio of Pythagoras.Geometry Index'.
	}