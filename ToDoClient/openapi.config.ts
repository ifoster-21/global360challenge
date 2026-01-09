import { GeneratorConfig } from 'ng-openapi';

const config: GeneratorConfig = {
  input: './todo.json',
  output: './src/api',
  options: {
    dateType: 'Date',
    enumStyle: 'enum'
  }
};

export default config;