updateInstancesFrom: oldClass 
	"Recreate any existing instances of the argument, oldClass, as instances of 
	the receiver, which is a newly changed class. Permute variables as 
	necessary."
	| oldInstances |

	oldInstances _ oldClass allInstances asArray.
	self updateInstances: oldInstances from: oldClass isMeta: true.
	"Now fix up instances in segments that are out on the disk."
	ImageSegment allSubInstancesDo: [:seg |
		seg segUpdateInstancesOf: oldClass toBe: self isMeta: true].