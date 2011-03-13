setCategoryDocumentationStrings
	"Initialize the documentation strings associated with the old etoy categories"

	#(
		(basic				'vitu muhimu')
		('color & border'	'rangi na kadhalika')
		(geometry 			'sijui neno hilo')
		(motion 			'kusogea')
		('pen use' 			'utumizi wa kalamu ya wino')
		(tests				'majaribio')
		(miscellaneous 		'mbali mbali')
		(slider				'oh yeah')
		(scripts				'methods added by this uniclass')
		('instance variables'	'instance variables added by this uniclass')) do:

		[:aPair |
			(self categoryAt: aPair first asSymbol) documentation: aPair second].