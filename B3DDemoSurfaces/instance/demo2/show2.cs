show2

    " B3DDemoSurfaces new show2"

     | view |

  self createScene2.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene2;
     scene: scene.
  view clearColor: (Color gray: 0.88).

  view rotateZ: 12.0.
  view openInSystemWindow.