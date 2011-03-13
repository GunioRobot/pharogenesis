setSelector: sel returnType: retType args: argList locals: localList declarations: decls primitive: primNumber parseTree: aNode labels: labelList complete: completeFlag
	"Initialize this method using the given information. Used for copying."

	selector _ sel.
	returnType _ retType.
	args _ argList.
	locals _ localList.
	declarations _ decls.
	primitive _ primNumber.
	parseTree _ aNode.
	labels _ labelList.
	complete _ completeFlag.