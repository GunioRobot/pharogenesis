declareHeaderFilesIn: aCCodeGenerator
	self headerFile ifNotNil:[
		aCCodeGenerator addHeaderFile: '"', self moduleName,'.h"'].