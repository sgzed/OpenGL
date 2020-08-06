#version 330 core
out vec4 FragColor;
   
uniform vec3 objectColor;
uniform vec3 lightColor;

in vec3 FragPos;
in vec3 Normal;
in vec3 lightPos;

void main() {

	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(lightPos - FragPos);
	float diff = max(dot(norm,lightDir),0.0);
	vec3 diffuse = diff * lightColor;

	float ambientStrength = 0.1;
	vec3 ambient = ambientStrength * lightColor;
	
	float specularStrength  = 0.5;
	vec3 viewDir = normalize(viewPos - FragPos);
	vec3 reflectDir = reflect(-lightDir,norm);
	
	float spec  = pow(max(dot(reflectDir,viewDir),0.0),256);
	vec3 specular  = specularStrength * spec * lightColor;
	
	vec3 result = (ambient + diffuse + specular)* objectColor;
    FragColor = vec4(result,1.0);
}