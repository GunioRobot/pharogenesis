changeColorIn: aMorph event: evt
	"Note: This is just a workaround to make sure we don't use the old color inst var"
	evt hand changeColorTarget: aMorph selector: #fillStyle: originalColor: self.