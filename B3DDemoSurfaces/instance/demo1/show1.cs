show1

    " B3DDemoSurfaces new show1"

     | view |

  self createScene1.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene1;
     scene: scene.
  view clearColor: (Color gray: 0.7).

  view rotateZ: 12.0.
  view openInSystemWindow.